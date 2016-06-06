//
//  _MDPAdImageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAdImageModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAdImageModelAttributes {
	__unsafe_unretained NSString *adImageUrl;
	__unsafe_unretained NSString *height;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *width;
} MDPAdImageModelAttributes;

extern const struct MDPAdImageModelRelationships {
	__unsafe_unretained NSString *advertisementLanguageAdImages;
} MDPAdImageModelRelationships;

@class MDPAdvertisementLanguageModel;

@interface _MDPAdImageModel : NSManagedObject

@property (nonatomic, strong) NSString* adImageUrl;

//- (BOOL)validateAdImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* height;

@property (atomic) int64_t heightValue;
- (int64_t)heightValue;
- (void)setHeightValue:(int64_t)value_;

//- (BOOL)validateHeight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* width;

@property (atomic) int64_t widthValue;
- (int64_t)widthValue;
- (void)setWidthValue:(int64_t)value_;

//- (BOOL)validateWidth:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *advertisementLanguageAdImages;

- (NSMutableSet*)advertisementLanguageAdImagesSet;

@end

@interface _MDPAdImageModel (AdvertisementLanguageAdImagesCoreDataGeneratedAccessors)
- (void)addAdvertisementLanguageAdImages:(NSSet*)value_;
- (void)removeAdvertisementLanguageAdImages:(NSSet*)value_;
- (void)addAdvertisementLanguageAdImagesObject:(MDPAdvertisementLanguageModel*)value_;
- (void)removeAdvertisementLanguageAdImagesObject:(MDPAdvertisementLanguageModel*)value_;
@end

@interface _MDPAdImageModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAdImageUrl;
- (void)setPrimitiveAdImageUrl:(NSString*)value;

- (NSNumber*)primitiveHeight;
- (void)setPrimitiveHeight:(NSNumber*)value;

- (int64_t)primitiveHeightValue;
- (void)setPrimitiveHeightValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveWidth;
- (void)setPrimitiveWidth:(NSNumber*)value;

- (int64_t)primitiveWidthValue;
- (void)setPrimitiveWidthValue:(int64_t)value_;

- (NSMutableSet*)primitiveAdvertisementLanguageAdImages;
- (void)setPrimitiveAdvertisementLanguageAdImages:(NSMutableSet*)value;

@end
