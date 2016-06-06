//
//  _MDPAdvertisementLanguageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAdvertisementLanguageModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAdvertisementLanguageModelAttributes {
	__unsafe_unretained NSString *adNavigationUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *localeCode;
	__unsafe_unretained NSString *pageOrientation;
} MDPAdvertisementLanguageModelAttributes;

extern const struct MDPAdvertisementLanguageModelRelationships {
	__unsafe_unretained NSString *adImages;
	__unsafe_unretained NSString *advertisementLanguages;
} MDPAdvertisementLanguageModelRelationships;

@class MDPAdImageModel;
@class MDPAdvertisementModel;

@interface _MDPAdvertisementLanguageModel : NSManagedObject

@property (nonatomic, strong) NSString* adNavigationUrl;

//- (BOOL)validateAdNavigationUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* localeCode;

//- (BOOL)validateLocaleCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageOrientation;

@property (atomic) uint16_t pageOrientationValue;
- (uint16_t)pageOrientationValue;
- (void)setPageOrientationValue:(uint16_t)value_;

//- (BOOL)validatePageOrientation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *adImages;

- (NSMutableOrderedSet*)adImagesSet;

@property (nonatomic, strong) MDPAdvertisementModel *advertisementLanguages;

//- (BOOL)validateAdvertisementLanguages:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPAdvertisementLanguageModel (AdImagesCoreDataGeneratedAccessors)
- (void)addAdImages:(NSOrderedSet*)value_;
- (void)removeAdImages:(NSOrderedSet*)value_;
- (void)addAdImagesObject:(MDPAdImageModel*)value_;
- (void)removeAdImagesObject:(MDPAdImageModel*)value_;
@end

@interface _MDPAdvertisementLanguageModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAdNavigationUrl;
- (void)setPrimitiveAdNavigationUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveLocaleCode;
- (void)setPrimitiveLocaleCode:(NSString*)value;

- (NSNumber*)primitivePageOrientation;
- (void)setPrimitivePageOrientation:(NSNumber*)value;

- (uint16_t)primitivePageOrientationValue;
- (void)setPrimitivePageOrientationValue:(uint16_t)value_;

- (NSMutableOrderedSet*)primitiveAdImages;
- (void)setPrimitiveAdImages:(NSMutableOrderedSet*)value;

- (MDPAdvertisementModel*)primitiveAdvertisementLanguages;
- (void)setPrimitiveAdvertisementLanguages:(MDPAdvertisementModel*)value;

@end
