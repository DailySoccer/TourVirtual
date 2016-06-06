//
//  _MDPCheckInTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCheckInTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCheckInTypeModelAttributes {
	__unsafe_unretained NSString *idCheckInType;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *proximity;
	__unsafe_unretained NSString *radius;
} MDPCheckInTypeModelAttributes;

extern const struct MDPCheckInTypeModelRelationships {
	__unsafe_unretained NSString *contents;
	__unsafe_unretained NSString *descriptionCheckInType;
	__unsafe_unretained NSString *location;
	__unsafe_unretained NSString *pagedCheckInTypeModelResults;
} MDPCheckInTypeModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPLocationModel;
@class MDPPagedCheckInTypeModel;

@interface _MDPCheckInTypeModel : NSManagedObject

@property (nonatomic, strong) NSString* idCheckInType;

//- (BOOL)validateIdCheckInType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* imageUrl;

//- (BOOL)validateImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* proximity;

@property (atomic) double proximityValue;
- (double)proximityValue;
- (void)setProximityValue:(double)value_;

//- (BOOL)validateProximity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* radius;

@property (atomic) int64_t radiusValue;
- (int64_t)radiusValue;
- (void)setRadiusValue:(int64_t)value_;

//- (BOOL)validateRadius:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *contents;

- (NSMutableSet*)contentsSet;

@property (nonatomic, strong) NSSet *descriptionCheckInType;

- (NSMutableSet*)descriptionCheckInTypeSet;

@property (nonatomic, strong) MDPLocationModel *location;

//- (BOOL)validateLocation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedCheckInTypeModel *pagedCheckInTypeModelResults;

//- (BOOL)validatePagedCheckInTypeModelResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCheckInTypeModel (ContentsCoreDataGeneratedAccessors)
- (void)addContents:(NSSet*)value_;
- (void)removeContents:(NSSet*)value_;
- (void)addContentsObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeContentsObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPCheckInTypeModel (DescriptionCheckInTypeCoreDataGeneratedAccessors)
- (void)addDescriptionCheckInType:(NSSet*)value_;
- (void)removeDescriptionCheckInType:(NSSet*)value_;
- (void)addDescriptionCheckInTypeObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionCheckInTypeObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPCheckInTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCheckInType;
- (void)setPrimitiveIdCheckInType:(NSString*)value;

- (NSString*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveProximity;
- (void)setPrimitiveProximity:(NSNumber*)value;

- (double)primitiveProximityValue;
- (void)setPrimitiveProximityValue:(double)value_;

- (NSNumber*)primitiveRadius;
- (void)setPrimitiveRadius:(NSNumber*)value;

- (int64_t)primitiveRadiusValue;
- (void)setPrimitiveRadiusValue:(int64_t)value_;

- (NSMutableSet*)primitiveContents;
- (void)setPrimitiveContents:(NSMutableSet*)value;

- (NSMutableSet*)primitiveDescriptionCheckInType;
- (void)setPrimitiveDescriptionCheckInType:(NSMutableSet*)value;

- (MDPLocationModel*)primitiveLocation;
- (void)setPrimitiveLocation:(MDPLocationModel*)value;

- (MDPPagedCheckInTypeModel*)primitivePagedCheckInTypeModelResults;
- (void)setPrimitivePagedCheckInTypeModelResults:(MDPPagedCheckInTypeModel*)value;

@end
