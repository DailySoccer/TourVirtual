//
//  _MDPPossessionIntervalModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPossessionIntervalModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPossessionIntervalModelAttributes {
	__unsafe_unretained NSString *away;
	__unsafe_unretained NSString *home;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *length;
	__unsafe_unretained NSString *middle;
	__unsafe_unretained NSString *range;
} MDPPossessionIntervalModelAttributes;

extern const struct MDPPossessionIntervalModelRelationships {
	__unsafe_unretained NSString *possessionIntervals;
} MDPPossessionIntervalModelRelationships;

@class MDPPossessionModel;

@interface _MDPPossessionIntervalModel : NSManagedObject

@property (nonatomic, strong) NSString* away;

//- (BOOL)validateAway:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* home;

//- (BOOL)validateHome:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* length;

@property (atomic) int64_t lengthValue;
- (int64_t)lengthValue;
- (void)setLengthValue:(int64_t)value_;

//- (BOOL)validateLength:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* middle;

//- (BOOL)validateMiddle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* range;

//- (BOOL)validateRange:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *possessionIntervals;

//- (BOOL)validatePossessionIntervals:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPossessionIntervalModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAway;
- (void)setPrimitiveAway:(NSString*)value;

- (NSString*)primitiveHome;
- (void)setPrimitiveHome:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLength;
- (void)setPrimitiveLength:(NSNumber*)value;

- (int64_t)primitiveLengthValue;
- (void)setPrimitiveLengthValue:(int64_t)value_;

- (NSString*)primitiveMiddle;
- (void)setPrimitiveMiddle:(NSString*)value;

- (NSString*)primitiveRange;
- (void)setPrimitiveRange:(NSString*)value;

- (MDPPossessionModel*)primitivePossessionIntervals;
- (void)setPrimitivePossessionIntervals:(MDPPossessionModel*)value;

@end
