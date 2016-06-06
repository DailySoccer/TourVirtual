//
//  _MDPLocationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLocationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLocationModelAttributes {
	__unsafe_unretained NSString *altitude;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *latitude;
	__unsafe_unretained NSString *longitude;
} MDPLocationModelAttributes;

extern const struct MDPLocationModelRelationships {
	__unsafe_unretained NSString *checkInLocation;
	__unsafe_unretained NSString *checkInTypeLocation;
} MDPLocationModelRelationships;

@class MDPCheckInModel;
@class MDPCheckInTypeModel;

@interface _MDPLocationModel : NSManagedObject

@property (nonatomic, strong) NSDecimalNumber* altitude;

//- (BOOL)validateAltitude:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* latitude;

//- (BOOL)validateLatitude:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* longitude;

//- (BOOL)validateLongitude:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *checkInLocation;

- (NSMutableSet*)checkInLocationSet;

@property (nonatomic, strong) NSSet *checkInTypeLocation;

- (NSMutableSet*)checkInTypeLocationSet;

@end

@interface _MDPLocationModel (CheckInLocationCoreDataGeneratedAccessors)
- (void)addCheckInLocation:(NSSet*)value_;
- (void)removeCheckInLocation:(NSSet*)value_;
- (void)addCheckInLocationObject:(MDPCheckInModel*)value_;
- (void)removeCheckInLocationObject:(MDPCheckInModel*)value_;
@end

@interface _MDPLocationModel (CheckInTypeLocationCoreDataGeneratedAccessors)
- (void)addCheckInTypeLocation:(NSSet*)value_;
- (void)removeCheckInTypeLocation:(NSSet*)value_;
- (void)addCheckInTypeLocationObject:(MDPCheckInTypeModel*)value_;
- (void)removeCheckInTypeLocationObject:(MDPCheckInTypeModel*)value_;
@end

@interface _MDPLocationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDecimalNumber*)primitiveAltitude;
- (void)setPrimitiveAltitude:(NSDecimalNumber*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDecimalNumber*)primitiveLatitude;
- (void)setPrimitiveLatitude:(NSDecimalNumber*)value;

- (NSDecimalNumber*)primitiveLongitude;
- (void)setPrimitiveLongitude:(NSDecimalNumber*)value;

- (NSMutableSet*)primitiveCheckInLocation;
- (void)setPrimitiveCheckInLocation:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCheckInTypeLocation;
- (void)setPrimitiveCheckInTypeLocation:(NSMutableSet*)value;

@end
