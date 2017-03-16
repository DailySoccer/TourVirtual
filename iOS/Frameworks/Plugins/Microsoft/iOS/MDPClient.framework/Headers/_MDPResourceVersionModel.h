//
//  _MDPResourceVersionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPResourceVersionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPResourceVersionModelAttributes {
	__unsafe_unretained NSString *appId;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *major;
	__unsafe_unretained NSString *minor;
} MDPResourceVersionModelAttributes;

@interface _MDPResourceVersionModel : NSManagedObject

@property (nonatomic, strong) NSString* appId;

//- (BOOL)validateAppId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* major;

@property (atomic) int64_t majorValue;
- (int64_t)majorValue;
- (void)setMajorValue:(int64_t)value_;

//- (BOOL)validateMajor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minor;

@property (atomic) int64_t minorValue;
- (int64_t)minorValue;
- (void)setMinorValue:(int64_t)value_;

//- (BOOL)validateMinor:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPResourceVersionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAppId;
- (void)setPrimitiveAppId:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMajor;
- (void)setPrimitiveMajor:(NSNumber*)value;

- (int64_t)primitiveMajorValue;
- (void)setPrimitiveMajorValue:(int64_t)value_;

- (NSNumber*)primitiveMinor;
- (void)setPrimitiveMinor:(NSNumber*)value;

- (int64_t)primitiveMinorValue;
- (void)setPrimitiveMinorValue:(int64_t)value_;

@end
