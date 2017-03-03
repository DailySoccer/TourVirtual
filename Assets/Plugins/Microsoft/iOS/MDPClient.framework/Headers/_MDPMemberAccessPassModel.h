//
//  _MDPMemberAccessPassModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMemberAccessPassModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMemberAccessPassModelAttributes {
	__unsafe_unretained NSString *code;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *qR;
} MDPMemberAccessPassModelAttributes;

@interface _MDPMemberAccessPassModel : NSManagedObject

@property (nonatomic, strong) NSString* code;

//- (BOOL)validateCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* qR;

//- (BOOL)validateQR:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMemberAccessPassModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCode;
- (void)setPrimitiveCode:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitiveQR;
- (void)setPrimitiveQR:(NSData*)value;

@end
