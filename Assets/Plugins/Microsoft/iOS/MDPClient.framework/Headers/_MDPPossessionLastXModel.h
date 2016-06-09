//
//  _MDPPossessionLastXModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPossessionLastXModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPossessionLastXModelAttributes {
	__unsafe_unretained NSString *away;
	__unsafe_unretained NSString *home;
	__unsafe_unretained NSString *lastMinutes;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPPossessionLastXModelAttributes;

extern const struct MDPPossessionLastXModelRelationships {
	__unsafe_unretained NSString *possessionLastX;
} MDPPossessionLastXModelRelationships;

@class MDPPossessionModel;

@interface _MDPPossessionLastXModel : NSManagedObject

@property (nonatomic, strong) NSString* away;

//- (BOOL)validateAway:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* home;

//- (BOOL)validateHome:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* lastMinutes;

@property (atomic) int64_t lastMinutesValue;
- (int64_t)lastMinutesValue;
- (void)setLastMinutesValue:(int64_t)value_;

//- (BOOL)validateLastMinutes:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *possessionLastX;

//- (BOOL)validatePossessionLastX:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPossessionLastXModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAway;
- (void)setPrimitiveAway:(NSString*)value;

- (NSString*)primitiveHome;
- (void)setPrimitiveHome:(NSString*)value;

- (NSNumber*)primitiveLastMinutes;
- (void)setPrimitiveLastMinutes:(NSNumber*)value;

- (int64_t)primitiveLastMinutesValue;
- (void)setPrimitiveLastMinutesValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPPossessionModel*)primitivePossessionLastX;
- (void)setPrimitivePossessionLastX:(MDPPossessionModel*)value;

@end
